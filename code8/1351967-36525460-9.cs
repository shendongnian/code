            void ChooseFirstDigit(Queue<int> hi, Queue<int> lo, LinkedList<int> digitPool)
            {
                bool hasZero = false;
                bool oddCount = (digitPool.Count % 2 != 0);
    
                // { 0, 1, 2, 4, 6, 7, 8}
                if (digitPool.First() == 0)
                {
                    hasZero = true;
                    digitPool.RemoveFirst(); // {1, 2, 4, 6, 7, 8}
                }
    
                if (oddCount)
                {
                    lo.Enqueue(digitPool.Last());
                    digitPool.RemoveLast();
                }
                else
                {
                    lo.Enqueue(digitPool.First()); //lo: 1
                    digitPool.RemoveFirst();
                }
                
                hi.Enqueue(digitPool.First()); //hi: 2
                digitPool.RemoveFirst();
    
                if (hasZero) digitPool.AddFirst(0);
            }
            void Solve()
            {
                int[] inputs = { 0, 1, 2, 4, 6, 7, 8 }; //Make sure its sorted
                LinkedList<int> digitPool = new LinkedList<int>(inputs);
                Queue<int> hi = new Queue<int>();
                Queue<int> lo = new Queue<int>();
    
                ChooseFirstDigit(hi, lo, digitPool);
                
                bool flag = true;
                while (digitPool.Count != 0)
                {
                    if (flag)
                    {
                        hi.Enqueue(digitPool.First());
                        digitPool.RemoveFirst();
                        flag = !flag;
                    }
                    else
                    {
                        lo.Enqueue(digitPool.Last());
                        digitPool.RemoveLast();
                        flag = !flag;
                    }
                }
    
                while(hi.Count != 0)
                    Console.Write(hi.Dequeue());
                Console.WriteLine("");
                while (lo.Count != 0)
                    Console.Write(lo.Dequeue());
            }
