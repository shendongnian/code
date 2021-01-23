    private static string _customAlphanumericOrder = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static bool Matches(string left_, string right_)
    {
        int maxLength = Math.Max(left_.Length, right_.Length);
        left_ = left_.PadRight(maxLength, '0').ToUpperInvariant();
        right_ = right_.PadRight(maxLength, '0').ToUpperInvariant();
        for (int index = 0; index < maxLength; index++)
        {
            int leftOrderPosition = _customAlphanumericOrder.IndexOf(left_[index]);
            int rightOrderPosition = _customAlphanumericOrder.IndexOf(right_[index]);
            if (leftOrderPosition > rightOrderPosition)
            {
                return true;
            }
            if (leftOrderPosition < rightOrderPosition)
            {
                return false;
            }
        }
        return false;
    }
