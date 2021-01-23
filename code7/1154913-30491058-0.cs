 public T GetElem(int index)
        {
            var it = outerInstance.iterator();
            it.Reset();
            var i = 0;
            while (it.MoveNext() && i < index)
            {
                i++;
            }
            return it.Current;
        }
