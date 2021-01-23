    <TextBox HorizontalAlignment="Stretch" Name="txtusername" Height="23" TextWrapping="Wrap" VerticalAlignment="Center" >
                <TextBox.Text>
                    <Binding Path="username" UpdateSourceTrigger="PropertyChanged">
                        <Binding.ValidationRules>
                            <l:CustomValidator ControlName="username" />
                        </Binding.ValidationRules>
                    </Binding>
                </TextBox.Text>
            </TextBox>
 
    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new Test();
            }
        }
    
        public class Test
        {
            public string username { get; set; }
        }
    
        public class CustomValidator : ValidationRule
        {
            public string ControlName { get; set; }
    
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                string letter = "/[a-zA-Z]/";
                string number = "/[0-9]/";
                string val = null;
                if (value != null)
                {
                    val = value.ToString();
                }
    
                String regex = "/^[A-Za-z0-9]+(?:[ _-][A-Za-z0-9]+)*$/";
                if (this.ControlName.ToString() == "username")
                {
                    if (val == "" || val == null)
                    {
                        return new ValidationResult(false, "Please enter a valid Username ");
                    }
                }
                else if (this.ControlName.ToString() == "password")
                {
                    if (val == null || val == "" || val.Length < 4 || val.Length > 15)
                    {
                        return new ValidationResult(false, "Please enter a Valid password");
                    }
                }
    
                return new ValidationResult(true, null);
            }
        }
