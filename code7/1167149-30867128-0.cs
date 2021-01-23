        ClassB {
            _private ClassA instanceOfA;
            public ClassB() {
                istanceOfA = new ClassA();
            }
            private void DoWork()
            {
                foreach(var node in instanceOfA.Nodes)
                {
                    // Do Something
                }
            }
        }
