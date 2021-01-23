    public static string GetNearestColorName(Vector3 vect)
            {
                var cr = GetClosestColor(GetColorReferences(), vect);
                if( cr != null )
                {
                    return cr.Name;
                }
                else
                    return string.Empty;
            }
    
