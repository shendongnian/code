    public partial class CourierDeliveringEnemyReport : Form
    {
    public static string Label1 { get; set; }
    public static string Label2 { get; set; }
    public static string Label3 { get; set; }
    public static string Label4 { get; set; }
    public static string Label5 { get; set; }
    public string Label6 { get; set; }
    public CourierDeliveringEnemyReport()
    {
        InitializeComponent();
        UpdateLabels();  // this will clear all labels except Label6
    }
    public void UpdateLabels()
    {
        label1.Text = Label1;
        label2.Text = Label2;
        label3.Text = Label3;
        label4.Text = Label4;
        label5.Text = Label5;
        label6.Text = "This is a test!";
    }
    CourierDeliveringEnemyReport dlg = new CourierDeliveringEnemyReport();
    CourierDeliveringEnemyReport.Label1 = "Report from " + BlueArmy[GameEventList[i].ObservingUnit].Name; ;
    string temp2 = "Enemy unit (" + RedArmy[GameEventList[i].Unit].Name + ") observed!";
    CourierDeliveringEnemyReport.Label2 = temp2;
    string temp3 = "This intelligence is " + RedArmy[GameEventList[i].Unit].LastTimeObservedByEnemy + " minutes old.";
    CourierDeliveringEnemyReport.Label3 = temp3;
    CourierDeliveringEnemyReport.UpdateLabels();
