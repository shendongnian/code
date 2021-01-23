    var numbers = new LinkedList<int>(new[]
                            {
                                488, 612, 803, 1082, 1310, 1586, 1899
                            });
                var sum = 0;
                var node = numbers.First;
                while (node.Next != null)
                {
                    var cur = node;
                    node = node.Next;
                    Console.WriteLine(node.Value - cur.Value);
                    sum += node.Value - cur.Value;
                }
                Console.WriteLine("********************");
                Console.WriteLine($"Sum is : {sum}");
