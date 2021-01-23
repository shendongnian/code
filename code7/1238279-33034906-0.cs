    namespace TokenSearch
    {
        internal static class Program
        {
            private static void Main()
            {
                var token = typeof (Class1).GetProperty("TargetProp").GetGetMethod().MetadataToken;
    
                const BindingFlags findAll = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
                                             BindingFlags.Instance | BindingFlags.Static;
                var references =
                    typeof (Program).Assembly.ManifestModule.GetTypes()
                        .SelectMany(x => x.GetMethods(findAll).Cast<MethodBase>().Union(x.GetConstructors(findAll)))
                        .ToDictionary(y => y, y => y.GetMethodUsageOffsets(token).ToArray())
                        .Where(z => z.Value.Length > 0).ToList();
    
                foreach (var kv in references)
                {
                    Console.WriteLine(
                        $"{kv.Key.DeclaringType}::{kv.Key.Name}: {string.Join(" ", kv.Value.Select(x => $"0x{x:x}"))}");
                }
            }
        }
    
        //some tests
        public class Class1
        {
            public string TargetProp { get; set; }
    
            private void TestMethod()
            {
                TargetProp = "123";
                var x = TargetProp;
                var y = TargetProp;
            }
        }
    
        public class Class2
        {
            private string c1 = new Class1().TargetProp;
    
            public void MoreMethods()
            {
                var c = new Class1();
                var x = c.TargetProp;
            }
    
            public void CantFindThis()
            {
                var c = new Class1();
                var x = c.ToString();
            }
        }
    
        public static class Extensions
        {
            private static readonly Dictionary<short, OpCode> OpcodeDict =
                typeof (OpCodes).GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Select(x => (OpCode) x.GetValue(null))
                    .ToDictionary(x => x.Value, x => x);
    
            public static IEnumerable<short> GetMethodUsageOffsets(this MethodBase mi, int token)
            {
                var il = mi.GetMethodBody()?.GetILAsByteArray();
                if (il == null) yield break;
                using (var br = new BinaryReader(new MemoryStream(il)))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        var firstByte = br.ReadByte();
                        var opcode =
                            OpcodeDict[
                                firstByte != 0xFE
                                    ? firstByte
                                    : BitConverter.ToInt16(new[] {br.ReadByte(), firstByte}, 0)];
                        switch (opcode.OperandType)
                        {
                            case OperandType.ShortInlineBrTarget:
                            case OperandType.ShortInlineVar:
                            case OperandType.ShortInlineI:
                                br.ReadByte();
                                break;
                            case OperandType.InlineVar:
                                br.ReadInt16();
                                break;
                            case OperandType.InlineField:
                            case OperandType.InlineType:
                            case OperandType.ShortInlineR:
                            case OperandType.InlineString:
                            case OperandType.InlineSig:
                            case OperandType.InlineI:
                            case OperandType.InlineBrTarget:
                                br.ReadInt32();
                                break;
                            case OperandType.InlineI8:
                            case OperandType.InlineR:
                                br.ReadInt64();
                                break;
                            case OperandType.InlineSwitch:
                                var size = (int) br.ReadUInt32();
                                br.ReadBytes(size*4);
                                break;
                            case OperandType.InlineMethod:
                            case OperandType.InlineTok:
                                if (br.ReadInt32() == token)
                                {
                                    yield return (short) (br.BaseStream.Position - 4 - opcode.Size);
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
