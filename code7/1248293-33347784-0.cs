    public partial class DEALER
    {
        public string ModelList { 
            get 
            {
                if (MODEL_NAME != null)
                {
                    return string.Join(",", DEALER_MODEL.Select(i => i.MODEL_NAME.ToString()).ToArray());
                }
                return "";
            }
        }
    }
