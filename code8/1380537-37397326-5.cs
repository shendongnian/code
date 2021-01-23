        static Action<object> WrapOperation(Action<object> action)
        {
            return new Action<object>(
                obj =>
            {
                Console.Write("Operation is started  ");
                Thread.Sleep(1500);
                action.Invoke(obj);
                Thread.Sleep(1500);
                Console.Write("   " + "Operation is finished");
            });
        }
