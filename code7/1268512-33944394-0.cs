    int value = 7000000;
    GiftConfig gift = m_Gifts.FirstOrDefault(x => value >= x.From && value <= x.To);
    // Returns Id 1
    value = 10000000;
    gift = m_Gifts.FirstOrDefault(x => value >= x.From && value <= x.To);
    // Returns Id 2
    value = 999999999;
    gift = m_Gifts.FirstOrDefault(x => value >= x.From && value <= x.To);
    // Returns null (assuming GiftConfig is a class).
