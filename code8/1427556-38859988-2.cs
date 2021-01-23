    class Program {
        static void Main(string[] args) {
            FormMiddleMan big = new FormBig();
            FormMiddleMan small = new FormSmall();
            big.DoJob(null); // FormBig
            small.DoJob(null); // FormSmall
            Console.ReadLine();
        }
    }
    class Form {
        
    }
    abstract class FormMiddleMan : Form {
        public abstract void DoJob(object parametersYouNeed);
    }
    class FormBig : FormMiddleMan {
        public override void DoJob(object parametersYouNeed) {
            Console.WriteLine("FormBig");
        }
    }
    class FormSmall : FormMiddleMan {
        public override void DoJob(object parametersYouNeed) {
            Console.WriteLine("FormSmall");
        }
    }
