        void Solve()
        {
            int[] inputs = { 6, 7, 8, 9 }; //Make sure its sorted
            LinkedList<int> digitPool = new LinkedList<int>(inputs);
            Queue<int> hi = new Queue<int>();
            Queue<int> lo = new Queue<int>();
            ChooseFirstDigit(hi, lo, digitPool);
            // {0, 4, 6, 7}
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
            while (hi.Count != 0)
                Console.Write(hi.Dequeue());
            Console.WriteLine("");
            while (lo.Count != 0)
                Console.Write(lo.Dequeue());
        }
        void ChooseFirstDigit(Queue<int> hi, Queue<int> lo, LinkedList<int> digitPool)
        {
            bool hasZero = false;
            bool oddCount = (digitPool.Count % 2 != 0);
            // { 0, 1, 2, 4, 6, 7, 8}
            if (digitPool.First() == 0)
            {
                hasZero = true;
                digitPool.RemoveFirst(); // {1, 2, 4, 6, 7}
            }
            if (oddCount)
            {
                hi.Enqueue(digitPool.First());              
                lo.Enqueue(digitPool.Last());
                digitPool.RemoveFirst();
                digitPool.RemoveLast();
            }
            else
            {
                var bestPair = digitPool.First;
                List<int> minGap = calculateGap(bestPair, hasZero);
                var pair = bestPair.Next; //pair[0,1]
                while (pair != digitPool.Last)
                {
                    List<int> gap = calculateGap(pair, hasZero);
                    for (int i = 0; i < gap.Count; ++i)
                    {
                        if (gap[i] < minGap[i])
                        {
                            //found a better pair
                            minGap = gap;
                            bestPair = pair;
                            break;
                        }
                    }
                    pair = pair.Next;               
                }
                lo.Enqueue(bestPair.Value);
                hi.Enqueue(bestPair.Next.Value);
                digitPool.Remove(bestPair.Next);
                digitPool.Remove(bestPair);
            }       
            if (hasZero) digitPool.AddFirst(0);
        }
        List<int> calculateGap(LinkedListNode<int> bestPair, bool hasZero)
        {
            LinkedList<int> clonedPool = new LinkedList<int>(bestPair.List);
            clonedPool.Remove(bestPair.Value);
            clonedPool.Remove(bestPair.Next.Value);
            List<int> gap = new List<int>();
            gap.Add(bestPair.Next.Value - bestPair.Value); //Level-1 GAP
            if (hasZero) clonedPool.AddFirst(0);
            while (clonedPool.Count != 0) //Sub-level GAPs
            {
                gap.Add((10 - clonedPool.Last()) + clonedPool.First());
                clonedPool.RemoveFirst();
                clonedPool.RemoveLast();
            }
            return gap;
        }
