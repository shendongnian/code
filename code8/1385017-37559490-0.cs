    public class TickList{
        IQueryable<Foo> _query;
        public TickList(){
            _query = from comp in Companies
                     join eqRes in Equity_issues on comp.Ticker equals eqRes.Ticker
                     select new Foo {
                         LocalTick = eqRes.Local_ticker.Trim(),
                         Exchange = eqRes.Exchange_code.Contains("HKSE") ? "HK" :(eqRes.Exchange_code.Contains("NSDQ") ? "NASDQ" : eqRes.Exchange_code),
                         Ticker = comp.Ticker.Trim()
                     };
        }
        public void WhereCoverageContains(string text){
            _query = _query.Where(x => x.Coverage_Status.Contains(text));
        }
        public void WherePrimaryEquityIs(string text){
            _query = _query.Where(x => x.PrimaryEquity.Equals(text));
        }
        public List<Foo> ToList(){
            return _query.ToList();
        }
    }
 
