        // This will return enumValues and enumNames sorted by the values.
        private void GetEnumData(out string[] enumNames, out Array enumValues)
        {
            Contract.Ensures(Contract.ValueAtReturn<String[]>(out enumNames) != null);
            Contract.Ensures(Contract.ValueAtReturn<Array>(out enumValues) != null);
 
            FieldInfo[] flds = GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
 
            object[] values = new object[flds.Length];
            string[] names = new string[flds.Length];
 
            for (int i = 0; i < flds.Length; i++)
            {
                names[i] = flds[i].Name;
                values[i] = flds[i].GetRawConstantValue();
            }
 
            // Insertion Sort these values in ascending order.
            // We use this O(n^2) algorithm, but it turns out that most of the time the elements are already in sorted order and
            // the common case performance will be faster than quick sorting this.
            IComparer comparer = Comparer.Default;
            for (int i = 1; i < values.Length; i++)
            {
                int j = i;
                string tempStr = names[i];
                object val = values[i];
                bool exchanged = false;
 
                // Since the elements are sorted we only need to do one comparision, we keep the check for j inside the loop.
                while (comparer.Compare(values[j - 1], val) > 0)
                {
                    names[j] = names[j - 1];
                    values[j] = values[j - 1];
                    j--;
                    exchanged = true;
                    if (j == 0)
                        break;
                }
 
                if (exchanged)
                {
                    names[j] = tempStr;
                    values[j] = val;
                }
            }
 
            enumNames = names;
            enumValues = values;
        }
