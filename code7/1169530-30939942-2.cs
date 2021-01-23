        static List<FactoryOrder> MergeValues(List<FactoryOrder> dirtyList)
        {            
            FactoryOrder[] temp1 = dirtyList.ToArray();
            int index = -1;
            for (int i = 1; i < temp1.Length; i++)
            {
                if (temp1[i].OrderNo - temp1[i - 1].OrderNo != 1) { index = -1; continue; }
                if(index == -1 ) index = dirtyList.IndexOf(temp1[i - 1]); 
                dirtyList[index].Text += " " + temp1[i].Text;                
                dirtyList.Remove(temp1[i]);
            }
            return dirtyList;
        }
