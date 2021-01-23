            List<myItem> list;
            //list.Sort(<.. sort by id ..>);
            int count = list.Count();
            for (int i = 0; i < count; i++)
            {
                myItem m = list[i];
                m.Sum1 = m.Value;                
                m.Sum2 = (i+1 < count) ? (m.Value + list[i+1].Value) : m.Value;
                m.Sum3 = (i+2 < count) ? (m.Sum2 + list[i+2].Value) : m.Sum2;                
            }
