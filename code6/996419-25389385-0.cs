    using System;
    using System.IO;
    using System.Text;
    
    public class P{
        public static void Main(string[] args) {
            StringBuilder message = new StringBuilder();
            message.AppendFormat("{0,-20}{1}","Items1:",1).AppendLine();
            message.AppendFormat("{0,-20}{1}","Items2Byb:",2).AppendLine();
            message.AppendFormat("{0,-20}{1}","Items3STCDEE:", 3).AppendLine();
            message.AppendFormat("{0,-20}{1}","Items4HTECEEGG:",4).AppendLine();
            message.AppendFormat("{0,-20}{1}","ItemsASSTEC:",5).AppendLine();
            Console.WriteLine(message.ToString());
        }
    }
