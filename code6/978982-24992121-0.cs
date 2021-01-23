        public byte[] GetReport(int Report_Type_Requested, object Report_Params)
        {
            Scripting.Dictionary dic = (Scripting.Dictionary)Report_Params;
            foreach (string key in dic)
            {
                object value = dic.get_Item(key);
            }
            ...
        }
