    public IEnumerator<Item> GetEnumerator()
            {
                    for (Node<Item> item = startNode; item != null; item = item.next)
                    {
                        yield return item.data;
                    }
            }
