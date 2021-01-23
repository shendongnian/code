    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Array of arrays");
            string[][] tt = new string[2][];
            tt[0] = new string[2];
            tt[1] = new string[3]; // Second row is longer!
            tt[0][0] = "Top left";
            tt[0][1] = "Top right";
            tt[1][0] = "Bottom left";
            tt[1][1] = "Bottom right";
            tt[1][2] = "Bottom extra right";
    
            NestedLoops(tt);
            Flatten(tt);
        }
    
        private static void NestedLoops(string[][] tt) {
            Console.WriteLine("  Nested:");
            for (int outerIdx = 0; outerIdx < tt.Length; ++outerIdx) {
                var inner = tt[outerIdx];
                for (int innerIdx = 0; innerIdx < inner.Length; ++innerIdx) {
                    Console.WriteLine("    [{0}, {1}] = " + inner[innerIdx], outerIdx, innerIdx);
                }
            }
        }
    
        private static void Flatten(IEnumerable<string[]> tt) {
            Console.WriteLine("  Falattened:");
            var values = tt.SelectMany((innerArray, outerIdx)
                                    => innerArray.Select((string val, int innerIdx)
                                        => new { OuterIndex = outerIdx, InnerIndex = innerIdx, Value = val }));
            foreach (var val in values) {
                Console.WriteLine("    [{0}, {1}] = " + val.Value, val.OuterIndex, val.InnerIndex);
            }
        }
    
    }
