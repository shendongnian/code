    public string GetAvgSeatPrice(string bu, string region, DateTime? startDate, DateTime? endDate)
        {
            var averageSeatPrice = (
                from r in db.Registrations
                where (bu == "ALL" || r.BusinessUnit.Equals(bu))
                && (region == "ALL" || r.Region.Equals(region))
                && r.StartDate >= startDate
                && r.EndDate <= endDate
                && r.ActualPrice > 0
                select r.ActualPrice).Average();
            var AvgSeatPrice = "$" + string.Format("{0:0.00}", averageSeatPrice);
            return AvgSeatPrice;
        }
