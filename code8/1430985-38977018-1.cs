    public class AdditionalParameters : RequestParameters
    {
        ///<summary>Detailed User-Friendly Descriptions.</summary>
        int? Param42 { get; set; };
        ...
        string Param70 { get; set; }
        public override object GetHashKey()
        {
            return new { base.GetHashKey(), Param42, ..., Param70 };
        }
    }
