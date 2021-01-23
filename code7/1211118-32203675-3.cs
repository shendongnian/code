    public static class FormManager
    {
        private static List<Form> formList = new List<Form>();
        public static void registerForm(Form form)
        {
            if (!formList.Contains(form)) formList.Add(form);
        }
        public static void unRegisterForm(Form form)
        {
            if (formList.Contains(form)) formList.Remove(form);
        }
        public static void setAllBackcolors(Color backColor)
        {
            foreach (Form f in formList) if (f != null) f.BackColor = backColor;
        }
    }
