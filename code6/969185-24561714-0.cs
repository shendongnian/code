    public class YourModel
    {
        public int CalculatedDays
        {
            get
            {
                QuoteApp.Models.Quote ts = new QuoteApp.Models.Quote();
                ts.StartDate = first;
                ts.EndDate = second;
                return (ts.EndDate - ts.StartDate);
            }
        }
    }
    @Html.EditorFor(model => model.CalculatedDays, new { htmlAttributes = new { @class = "form-control", disabled = "disabled"} })
