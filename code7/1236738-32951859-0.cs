    public class HGProgramViewModel
    {
        // other HGProgram properties you want to edit
        public string Child1GiftTypeNeed { get; set; }
        public List<string> Child1GiftTypeNeedList
        {
            get
            {
                !string.IsNullOrWhiteSpace(Child1GiftTypeNeed)
                    ? Child1GiftTypeNeed.Split(',').ToList()
                    : new List<string>();
            }
            set
            {
                Child1GiftTypeNeed = value != null
                    ? string.Join(",", value)
                    : null;
            }
        }
    }
