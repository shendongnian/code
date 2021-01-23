    public static List<Asn1Object> FindAsn1Values(string oid, Asn1Object obj)
    {
        Asn1Object result = null;
        List<Asn1Object> results = new List<Asn1Object>();
        if (obj is Asn1Sequence)
        {
            bool foundOID = false;
            foreach (Asn1Object entry in (Asn1Sequence)obj)
            {
                var derOID = entry as DerObjectIdentifier;
                if (derOID != null && derOID.Id == oid)
                {
                    foundOID = true;
                }
                else if (foundOID)
                {
                    results.Add(entry);
                } 
                else
                {
                    result = FindAsn1Values(oid, entry);
                    if (result.Count > 0)
                    {
                        results.AddRange(result);
                    }
                }
            }
        }
        else if (obj is DerTaggedObject)
        {
            result = FindAsn1Values(oid, ((DerTaggedObject)obj).GetObject());
            if (result.Count > 0)
            {
                results.AddRange(result);
            }
        }
        else
        {
            if (obj is DerSet)
            {
                foreach (Asn1Object entry in (DerSet)obj)
                {
                    result = FindAsn1Values(oid, entry);
                    if (result.Count > 0)
                    {
                        results.AddRange(result);
                    }
                }
            }
        }
        return results;
    }
