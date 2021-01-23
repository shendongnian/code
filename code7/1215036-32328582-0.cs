    public static Asn1Object FindAsn1Value(string oid, Asn1Object obj)
    {
        Asn1Object result = null;
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
                    return entry;
                } 
                else
                {
                    result = FindAsn1Value(oid, entry);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
        }
        else if (obj is DerTaggedObject)
        {
            result = FindAsn1Value(oid, ((DerTaggedObject)obj).GetObject());
            if (result != null)
            {
                return result;
            }
        }
        else
        {
            if (obj is DerSet)
            {
                foreach (Asn1Object entry in (DerSet)obj)
                {
                    result = FindAsn1Value(oid, entry);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
        }
        return null;
    }
