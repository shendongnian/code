      class ChildFuntionExecutor
        {
            public Func<int,int> ChildFuntion;
            public int Operand1;
            public void Evaluate()
            {
                 ChildFuntion(Operand1);
            }
        }
        bool Watch { get; set; }
        // Parent is control center, calling one child after another
        void Parent()
        {
            // register all child functions 
            List<ChildFuntionExecutor> childFuntionQueue = new List<ChildFuntionExecutor>();
            childFuntionQueue.Add(new ChildFuntionExecutor { Operand1 = 10, ChildFuntion = this.ChildOne });
            childFuntionQueue.Add(new ChildFuntionExecutor { Operand1 = 10, ChildFuntion = this.ChildOne });
            foreach (var item in childFuntionQueue)
            {
                item.Evaluate();
                if (Watch == false)
                    return;
            }
        }
        /// signature type 1
        int ChildOne(int a)
        {
            return a * 10;
        }
        /// signature type 1
        int ChildTwo(int a)
        {
            Watch = false;
            return a * 10;
        }
