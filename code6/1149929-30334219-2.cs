    public class RetrieveData
    {
        public string StoreName { get; set; }
        public string SectionName { get; set; }
        public int Sqft { get; set; }
        public int Amount { get; set; }
    }
    public void Method(tStore store)
    {
        // Store_Name, Section_Name, Sqft, Amount
 
        var list = from se in Context.Sections
                   join fs in tSectionForwardSelling on se.SectionID equals fs.SectionID 
                   join sqft in tSectionSqft on se.SectionID equals sqft.SectionID
                   join st in tStore on new { u1 = fs.StoreID , u2 = st.StoreID } equals new { u1 = sqft.StoreID , u2 = st.StoreID }
                   select new RetrieveData() {
                       StoreName = st.Store_Name,
                       SectionName = se.Section_Name,
                       Sqft = sqft.Sqft,
                       Amount = fs.Amount };
    }
