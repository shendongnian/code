    class Heap
            {
                int[] items;
                int size = 0;
                public Heap() : this(16)
                {
                }
                public Heap(int initSize)
                {
                    if (initSize < 1)
                    {
                        throw new ArgumentException("Size must be greater than 0");
                    }
                    items = new int[initSize];
                }
    
    
                /*Method which push up the elment after adding it on the last place
                k - last index/ when k=0, element is on the top of the heap
                p - parent index/ item - value of element/ parent - value of parent */
                private void PushUp()
                {
                    int k = size - 1;
                    while (k > 0)
                    {
                        int p = (k - 1) / 2;
                        int item = items[k];
                        int parent = items[p];
                        if (item > parent)
                        {
                            //Swap of elements
                            items[k] = parent;
                            items[p] = item;
                            k = p;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
    
                // Method which put element in correct place of the heap
                public void Insert(int value)
                {
                    if (items.Length <= size)
                    {
                        Array.Resize(ref items, items.Length * 2);
                    }
                    items[size++] = value;
                    PushUp();
                }
    
                public bool IsEmpty()
                {
                    return size == 0;
                }
    
                /* After deleting item from the heap we have to push down element to check if heap structure is correct
                k - index of first element, top of the heap/ l - left "child" index / r - right child index
                max is max value - either right or left child  */
                private void PushDown(int k)
                {
                    int l = 2 * k + 1;
                    while (l < size)
                    {
                        int max = l;
                        int r = l + 1;
                        if (r < size)
                        {
                            if (items[r] > items[l])
                            {
                                //max become right child
                                max = r;
                            }
                        }
                        if (items[k] < items[max])
                        {
                            //swap of 2 values, prevous element and next element are swapped
                            int temp = items[k];
                            items[k] = items[max];
                            items[max] = temp;
                        }
                        else
                        {
                            break;
                        }
                        k = max;
                        l = 2 * k + 1;
                    }
                }
    
                //Deleting item from the top of the heap
                public int Pop()
                {
                    if (size == 0)
                    {
                        throw new DataException("No elements to delete");
                    }
                    else if (size == 1)
                    {
                        return items[--size];
                    }
                    else
                    {
                        int ret = items[0];
                        items[0] = items[--size];
                        PushDown(0);
                        return ret;
                    }
                }
            }
