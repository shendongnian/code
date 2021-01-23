    public static bool IsAt
    {
        get
        {
            return (Driver.Instance.FindElements(By.CssSelector("div.notice.success")).Count > 0);
        }
    }
