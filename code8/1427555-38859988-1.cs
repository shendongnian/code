    class Program {
        static void Main(string[] args) {
            Form big = new FormBig();
            Form small = new FormSmall();
            big.DoJob(null); // FormBig
            small.DoJob(null); // FormSmall
            Console.ReadLine();
        }
    }
    class Form {
        public virtual void DoJob(object parametersYouNeed) {
            throw new NotImplementedException("use only on inheritor");
        }
    }
    class FormBig : Form {
        public override void DoJob(object parametersYouNeed) {
            Console.WriteLine("FormBig");
        }
    }
    class FormSmall : Form {
        public override void DoJob(object parametersYouNeed) {
            Console.WriteLine("FormSmall");
        }
    }
