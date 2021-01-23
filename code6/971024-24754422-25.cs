    public partial class _Default : Page
    {
        List<CompanyModel1> companies1 = new List<CompanyModel1>();
        protected void Page_Init(object sender, EventArgs e)
        {
            companies1.Add(new CompanyModel1
            {
                compnSN1 = 1,
                compnId1 = "Test 1",
                compnKeySkills1 = "Key 1",
                compnStyle1 = "Style 1",
                compnStandards1 = "abc"
            });
            companies1.Add(new CompanyModel1
            {
                compnSN1 = 2,
                compnId1 = "Test 2",
                compnKeySkills1 = "Key 2",
                compnStyle1 = "Style 2",
                compnStandards1 = "abc"
            });
            companies1.Add(new CompanyModel1
            {
                compnSN1 = 3,
                compnId1 = "Test 3",
                compnKeySkills1 = "Key 3",
                compnStyle1 = "Style 3",
                compnStandards1 = "Iso 2004"
            });
        }
        
        public class CompanyModel1
        {
            public int compnSN1 { get; set; }
            public string compnStyle1 { get; set; }
            public string compnId1 { get; set; }
            public string compnKeySkills1 { get; set; }
            public string compnStandards1 { get; set; }
        }
    }
