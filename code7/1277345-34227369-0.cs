    public class Program
    {
        [Flags]
        private enum ModifierKeys
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }
        
        static void Main(string[] args)
        {
            ModifierKeys none = ModifierKeys.None;
            ModifierKeys alt = ModifierKeys.Alt;
            ModifierKeys control = ModifierKeys.Control;
            ModifierKeys shift = ModifierKeys.Shift;
            ModifierKeys windows = ModifierKeys.Windows;
            ShowEnums(none, alt, control, shift, windows);
           
            ShowAddingFlags(control, shift);
    
            ShowBitwiseAnd(none, alt, control, shift, windows);
    
    
            CompareWithShiftAndControl(alt, control, shift);
    
            Console.ReadKey();
        }
    
        private static void ShowBitwiseAnd(params ModifierKeys[] ms)
        {
            List<ModifierKeys> mods = new List<ModifierKeys>();
            mods.AddRange(ms);
    
            ModifierKeys c = ModifierKeys.None;
    
            Console.WriteLine("Adding all...");
    
            foreach (var m in mods)
            {
                Console.WriteLine(GetBinaryString(m));
                c = c | m;
            }
    
            Console.WriteLine(GetBinaryString(c));
            Console.WriteLine(c);
            Console.WriteLine();
        }
    
        private static void CompareWithShiftAndControl(params ModifierKeys[] ms)
        {
            var withAlt = ModifierKeys.Alt | ModifierKeys.Control | ModifierKeys.Shift;
            var withoutAlt = ModifierKeys.Control | ModifierKeys.Shift;
    
            Console.WriteLine("Using bitwise And:" );
    
            var formatter = "{0} & {1} = {2}";
            Console.WriteLine(formatter, GetBinaryString(withAlt), GetBinaryString(withoutAlt), GetBinaryString(withAlt & withoutAlt));
            Console.WriteLine(formatter, withAlt, withoutAlt, withAlt & withoutAlt);
            
        }
    
        private static void ShowAddingFlags(params ModifierKeys[] ms)
        {
            List<ModifierKeys> mods = new List<ModifierKeys>();
            mods.AddRange(ms);
    
            ModifierKeys c = ModifierKeys.None;
    
            Console.WriteLine("Adding Control and Shift...");
    
            foreach (var m in mods)
            {
                Console.WriteLine(GetBinaryString(m));
                c = c | m;
            }
    
            Console.WriteLine(GetBinaryString(c));
            Console.WriteLine(c);
            Console.WriteLine();
        }
    
        private static string GetBinaryString(ModifierKeys modifierKeys)
        {
            return Convert.ToString((int)modifierKeys, 2).PadLeft(8, '0'); 
        }
    
        private static void ShowEnums(params ModifierKeys[] ms)
        {
            List<ModifierKeys> mods = new List<ModifierKeys>();
            mods.AddRange(ms);
    
            foreach (var m in mods)
            {
                Console.WriteLine(m);
                Console.WriteLine(GetBinaryString(m));
            }
    
            Console.WriteLine();
        }
    }
