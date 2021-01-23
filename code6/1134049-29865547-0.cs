    object new_object = new object();
    new_object.text_prop = "sample text";
    new_object.number_prop = 3;
    comboBox1.Items.Insert(0, new_object);
    comboBox1.ValueMember = "number_prop";
    comboBox1.DisplayMember = "text_prop"
    class SomeObject
    {
        public string text_prop {get; set; }
        public int number_prop {get; set; }
        public override string ToString();
        {
            return text_prop;
        }
    }
