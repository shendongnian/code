    abstract class ListOfValues<T> : List<T>
    {
        protected abstract double GetItemValue(int i);
        protected abstract void SetItemValue(int i, double value);
        public void UpdateValues(double parameter)
        {
            for (int i = 0; i < this.Count; i++)
            {
                SetItemValue(, i, SomeFunction(GetItemValue(i), parameter));
            }
        }
    }
    class ListOfDouble : ListOfValues<double>
    {
        protected override double GetItemValue(int i)
        {
            return this[i];
        }
        protected override void SetItemValue(int i, double value)
        {
            this[i] = value;
        }
    }
    class ListOfComplexValue : ListOfValues<ComplexValue>
    {
        protected override double GetItemValue(int i)
        {
            return this[i].value;
        }
        protected override void SetItemValue(int i, double value)
        {
            this[i].value = value;
        }
    }
