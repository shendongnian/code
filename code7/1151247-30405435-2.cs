        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Collections.ObjectModel;
        using System.ComponentModel;
        using System.Reflection;
        namespace noughtsandcrosses
        {
            public class ViewModel : INotifyPropertyChanged
            {
                public RelayCommand<Cell> ButtonClickCommand { get; set; }
                public RelayCommand<string> ResetClickCommand { get; set; }
                public int NoughtsScore { get; set; }
                public int CrossesScore { get; set; }
                public int TotalScore { get; set; }
                private List<Row> _test;
                public List<Row> rows
                {
                    get { return _test; }
                    set { _test = value;  }
                }
                private Cell.CellState _turn;
                public Cell.CellState turn
                {
                    get { return _turn; }
                    set { _turn = value; }
                }
                private bool _GameOver;
                public bool GameOver
                {
                    get { return _GameOver; }
                    set { _GameOver = value; NotifyPropertyChanged("GameOver"); }
                }
        
                public ViewModel()
                {
                    ButtonClickCommand = new RelayCommand<Cell>(OnButtonClickCommand);
                    ResetClickCommand = new RelayCommand<string>(OnResetClickCommand);
                    // Start with Noughts going first
                    this.turn = Cell.CellState.Noughts;
                    // Add 3 blank rows
                    this.rows = new List<Row>();
                    this.rows.Add(new Row());
                    this.rows.Add(new Row());
                    this.rows.Add(new Row());
                }
                private void OnResetClickCommand(string obj)
                {
                    this.rows.Select(c => { c.Cell1.State = GetEnumDescription(Cell.CellState.None); c.Cell2.State = GetEnumDescription(Cell.CellState.None); c.Cell3.State = GetEnumDescription(Cell.CellState.None); return c; }).ToList();
                    this.NoughtsScore = 0;
                    this.CrossesScore = 0;
                    this.GameOver = false;
                    this.TotalScore = 0;
                }
                private void OnButtonClickCommand(Cell obj)
                {
                    bool winner = false;
                    if (obj.State == null)
                    {
                        obj.State = GetEnumDescription(this.turn);
                        // swap user..... don't like this but for 20min wonder someone else can fix it
                        if (this.turn == Cell.CellState.Noughts)
                        {
                            NoughtsScore += obj.Mask;
                            this.turn = Cell.CellState.Crosses;
                            winner = CheckForWinner(NoughtsScore);
                        }
                        else
                        {
                            CrossesScore += obj.Mask;
                            this.turn = Cell.CellState.Noughts;
                            winner = CheckForWinner(CrossesScore);
                        }
                        TotalScore += obj.Mask;
                    }
                    if (winner || CheckForGameOver(this.TotalScore))
                        this.GameOver = true;
                }
                private bool CheckForWinner(int Score)
                {
                    if ((Score & 7) == 7)
                        return true;
                    if ((Score & 56) == 56)
                        return true;
                    if ((Score & 448) == 448)
                        return true;
                    if ((Score & 73) == 73)
                        return true;
                    if ((Score & 146) == 146)
                        return true;
                    if ((Score & 292) == 292)
                        return true;
                    if ((Score & 273) == 273)
                        return true;
                    if ((Score & 84) == 84)
                        return true;
                    return false;
                }
                private bool CheckForGameOver(int TotalScore)
                {
                    if ((TotalScore & 511) == 511)
                        return true;
                    return false;
                }
                public static string GetEnumDescription(Enum value)
                {
                    FieldInfo fi = value.GetType().GetField(value.ToString());
                    DescriptionAttribute[] attributes =
                        (DescriptionAttribute[])fi.GetCustomAttributes(
                        typeof(DescriptionAttribute),
                        false);
                    if (attributes != null && attributes.Length > 0)
                        return attributes[0].Description;
                    else
                        return value.ToString();
                }
                public event PropertyChangedEventHandler PropertyChanged;
                private void NotifyPropertyChanged(string PropertyName)
                {
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
                }
            }
            public class Row
            {
                public Cell Cell1 { get; set; }
                public Cell Cell2 { get; set; }
                public Cell Cell3 { get; set; }
                public Row()
                {
                    this.Cell1 = new Cell();
                    this.Cell2 = new Cell();
                    this.Cell3 = new Cell();
                }
            }
            public class Cell : INotifyPropertyChanged
            {
                private static int power = 0;
                public enum CellState
                {
                    [Description(null)]
                    None,
                    [Description("O")]
                    Noughts,
                    [Description("X")]
                    Crosses
                }
                private string _State;
                public string State
                {
                    get { return _State; }
                    set { _State = value; NotifyPropertyChanged("State"); }
                }
                private int _Mask;
                public int Mask
                {
                    get { return _Mask; }
                    set { _Mask = value; }
                }
        
        
                public Cell()
                {
                    this.State = GetEnumDescription(CellState.None);
                    this.Mask = 1 << power;
                    power++;
                }
                public static string GetEnumDescription(Enum value)
                {
                    FieldInfo fi = value.GetType().GetField(value.ToString());
                    DescriptionAttribute[] attributes =
                        (DescriptionAttribute[])fi.GetCustomAttributes(
                        typeof(DescriptionAttribute),
                        false);
                    if (attributes != null && attributes.Length > 0)
                        return attributes[0].Description;
                    else
                        return value.ToString();
                }
                public event PropertyChangedEventHandler PropertyChanged;
                private void NotifyPropertyChanged(string PropertyName)
                {
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
                }
            }
        }
