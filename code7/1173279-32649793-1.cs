    // ************************** Ordered Dictionary - works ****************
    // http://stackoverflow.com/questions/2722767/c-sharp-order-preserving-data-structures
    // http://www.go4expert.com/articles/understanding-c-sharp-dictionaries-t30034/
    public OrderedDictionary m_oCol;
    public OrderedDictionary m_oColReverse;
    public clsFeatureCollection()
        : base()
    {
        m_oCol = new OrderedDictionary();
        m_oColReverse = new OrderedDictionary();
    }
    public IEnumerator GetEnumerator()
    {
        return m_oCol.GetEnumerator();
    }
    public void Add(IFeature pFeature, string strBefore = "", string strAfter = "", bool bReverse = false)
    {
        if (bReverse == true)
        {
            m_oColReverse.Add(pFeature.OID.ToString().Trim(), pFeature.OID.ToString().Trim());
        }
        if (!ContainsItem(pFeature.OID.ToString()))
        {
            m_oCol.Add(pFeature.OID.ToString(), new clsFeature(pFeature.OID, pFeature.ShapeCopy));
        }
    }
    public void AddBefore(IFeature pFeature, string strBefore, bool bReverse = false)
    {
        if (bReverse == true)
        {
            m_oColReverse.Add(pFeature.OID.ToString().Trim(), pFeature.OID.ToString().Trim());
        }
        if (!ContainsItem(pFeature.OID.ToString()))
        {
            if (strBefore != null)
            {
                int index = GetIndex(m_oCol, strBefore);
                if (index > 0)
                {
                    m_oCol.Insert(index - 1, pFeature.OID.ToString(), new clsFeature(pFeature.OID, pFeature.ShapeCopy));
                }
                else
                {
                    m_oCol.Insert(0, pFeature.OID.ToString(), new clsFeature(pFeature.OID, pFeature.ShapeCopy));
                }
            }
        }
    }
    public void AddAfter(IFeature pFeature, string strAfter, bool bReverse = false)
    {
        if (bReverse == true)
        {
            m_oColReverse.Add(pFeature.OID.ToString().Trim(), pFeature.OID.ToString().Trim());
        }
        if (!ContainsItem(pFeature.OID.ToString()))
        {
            if (!string.IsNullOrEmpty(strAfter))
            {
                int index = GetIndex(m_oCol, strAfter);
                m_oCol.Insert(index + 1, pFeature.OID.ToString(), new clsFeature(pFeature.OID, pFeature.ShapeCopy));
            }
            else
            {
                m_oCol.Insert(0, pFeature.OID.ToString(), new clsFeature(pFeature.OID, pFeature.ShapeCopy));
            }
        }
    }
    public int Count
    {
        get { return m_oCol.Count; }
    }
    public void Remove(int Id)
    {
        m_oCol.RemoveAt(Id);
    }
    public clsFeature Item(int Position)
    {
        try
        {
            clsFeature value = (clsFeature)m_oCol.Cast<DictionaryEntry>().ElementAt(Position).Value;
            return value;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void Clear()
    {
        m_oCol = new OrderedDictionary();
        m_oColReverse = new OrderedDictionary();
    }
    public bool Reverse(string valueRenamed)
    {
        bool bReverse = false;
        try
        {
            if (m_oColReverse.Contains(valueRenamed))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            if (ex is ArgumentException | ex is IndexOutOfRangeException)
            {
                bReverse = false;
            }
        }
        return bReverse;
    }
    public bool ContainsItem(string oidValue)
    {
        bool bContainsItem = false;
        string intOID = oidValue.ToString();
        try
        {
            // dictionary
            if (m_oCol.Contains(intOID))
            {
                bContainsItem = true;
            }
            else
            {
                bContainsItem = false;
            }
            return bContainsItem;
        }
        catch (Exception ex)
        {
            if (ex is ArgumentException | ex is IndexOutOfRangeException)
            {
                bContainsItem = false;
            }
        }
        return bContainsItem;
    }
    public static int GetIndex(OrderedDictionary dictionary, string key)
    {
        for (int index = 0; index < dictionary.Count; index++)
        {
            if (dictionary[index] == dictionary[key])
            {
                return index;
            }
        }
        return -1;
    }
    // ******************************  End Ordered Dictionary - works **********************
