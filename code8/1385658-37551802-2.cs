    class Program {
        static void Main(string[] args) {
            var p = new Program();
            p.SubOrUnsub(true);
            p.SubOrUnsub(false);
            Console.ReadKey();
        }
        void SubOrUnsub(bool flag) {
            Action<string> handler = (s) => {
                Console.WriteLine(s);
            };
            if (flag) {
                Test += handler;
                ShowInvocationList();
            }
            else {
                Test -= handler;
                ShowInvocationList();
            }
        }
        private void ShowInvocationList() {
            Console.WriteLine("Delegates: " + (Test?.GetInvocationList().Length ?? 0));
        }
        public event Action<string> Test;
    }
