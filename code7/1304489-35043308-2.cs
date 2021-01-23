    public infoUser() {
        InitializeComponent();
        MouseEnter += infoUser_MouseEnter;
        MouseLeave += infoUser_MouseLeave;
    }
    void infoUser_MouseLeave(object sender, EventArgs e) {
        Hover = false;
    }
    void infoUser_MouseEnter(object sender, EventArgs e) {
        Hover = true;   
    }
    bool hoverCore;
    protected bool Hover {
        get { return hoverCore; }
        set {
            if(hoverCore == value) return;
            hoverCore = value;
            OnHoverChanged();
        }
    }
    void OnHoverChanged() {
        ChangeColor(Hover ? Color.CadetBlue : Color.WhiteSmoke);
    }
