    // create a static group list to see if it works
    private List<Group<mTeachers>> GetUsersGroups(string Job)
    {
        List<mTeachers> usersList = new List<mTeachers>();
        usersList.Add(new mTeachers() { Name = "Bob", Income = 1000, Flag = new Uri(@"/Assets/AlignmentGrid.png", UriKind.Relative),  Job = "Guy" });
        usersList.Add(new mTeachers() { Name = "Dan", Income = 1000, Flag = new Uri(@"/Assets/AlignmentGrid.png", UriKind.Relative), Job = "Guy" });
        usersList.Add(new mTeachers() { Name = "Kate", Income = 2000, Flag = new Uri(@"/Assets/AlignmentGrid.png", UriKind.Relative), Job = "Girl" });
        usersList.Add(new mTeachers() { Name = "Charlie", Income = 2000, Flag = new Uri(@"/Assets/AlignmentGrid.png", UriKind.Relative), Job = "Guy" });
        usersList.Add(new mTeachers() { Name = "Jeff", Income = 2000, Flag = new Uri(@"/Assets/AlignmentGrid.png", UriKind.Relative), Job = "Guy" });
        usersList.Add(new mTeachers() { Name = "Jeff2", Flag = new Uri(@"/Assets/AlignmentGrid.png", UriKind.Relative), Job = "Guy" });
        return GetItemGroups(usersList, c => c.Income);
    }
    // Constructor
    public MainPage()
    {
        InitializeComponent();
        // create the user group and bind it to item source
        this.longlist2.ItemsSource = GetUsersGroups("whatever");
    }
