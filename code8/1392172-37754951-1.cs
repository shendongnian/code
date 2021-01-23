    public static class Extension
    {
        public static void clear(this InputField inputfield)
        {
            inputfield.Select();
            inputfield.text = "";
        }
    }
