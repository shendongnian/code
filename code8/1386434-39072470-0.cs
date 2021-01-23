     Private Sub sub_Form_Validators(ByVal f As Object)
            'For Loop for Getting all Fields in the Given form using control option
            For Each obj As Object In CType(f, Control).Controls
                If TypeOf obj Is TextBox Then
                    'For Text Box
                    Dim txt As TextBox = obj
                    txt.Font = New Font(fontname, fontsize, fs_fontstyle)
                    txt.ForeColor = Color.Black 'Color.FromName(forecolor)
                    txt.BorderStyle = BorderStyle.FixedSingle
                    AddHandler txt.EnabledChanged, AddressOf sub_textbox_EnabledChanged
                    AddHandler txt.GotFocus, AddressOf sub_Textbox_GotFocus_Validator
                    AddHandler txt.LostFocus, AddressOf sub_Textbox_LostFocus_Validator
                ElseIf TypeOf obj Is RichTextBox Then
                    Dim txt As RichTextBox = obj
                    txt.Font = New Font(fontname, fontsize, fs_fontstyle)
                    txt.ForeColor = Color.Black 'Color.FromName(forecolor)
                    AddHandler txt.EnabledChanged, AddressOf sub_RichTextBox_EnabledChanged
                    AddHandler txt.GotFocus, AddressOf sub_RichTextBox_GotFocus_Validator
                    AddHandler txt.LostFocus, AddressOf sub_RichTextBox_LostFocus_Validator
                ElseIf TypeOf obj Is TabControl Then            'For Tab Control
                    Dim tab As TabControl = obj
                    tab.BackColor = Color.FromName(backcolor) 'backcolor
                    sub_Form_Validators(obj)
    
                ElseIf TypeOf obj Is TabPage Then               'For Tab Page
                    Dim tabpage As TabPage = obj
                    tabpage.BackColor = Color.FromName(backcolor)
                    tabpage.ForeColor = Color.FromName(forecolor)
                    sub_Form_Validators(obj)
    
                ElseIf TypeOf obj Is RadioButton Then           'For Radio Button
                    Dim rbtn As RadioButton = obj
                    rbtn.BackColor = Color.FromName(backcolor)
                    rbtn.Font = New Font(fontname, fontsize, fs_fontstyle)
                    rbtn.ForeColor = Color.FromName(forecolor)
    
                ElseIf TypeOf obj Is CheckBox Then              'For Check Box
                    Dim chk As CheckBox = obj
                    chk.BackColor = Color.FromName(backcolor)
                    chk.ForeColor = Color.FromName(forecolor)
                    chk.Font = New Font(fontname, fontsize, fs_fontstyle)
    
                ElseIf TypeOf obj Is ComboBox Then              'For Combo box
                    Dim cmb As ComboBox = obj
                    'cmb.BackColor = Color.FromName(backcolor)
                    cmb.ForeColor = Color.FromName(forecolor)
                    AddHandler cmb.EnabledChanged, AddressOf cmb_EnabledChanged
                    AddHandler cmb.GotFocus, AddressOf Combobox_GotFocus_Validator
                    AddHandler cmb.LostFocus, AddressOf Combobox_LostFocus_Validator
                    cmb.Font = New Font(fontname, fontsize, fs_fontstyle)
                ElseIf TypeOf obj Is Button Then                'For Button
                    Dim btn As Button = obj
        
                        'btn.BackColor = Color.FromName(backcolor) ' backcolor 'Color.FromArgb(frmButtonColorRed, frmButtonColorGreen, frmButtonColorBlue)
                        btn.Font = New Font(fontname, fontsize, fs_fontstyle)
                        'btn.ForeColor = Color.FromName(forecolor)
                        btn.FlatStyle = FlatStyle.Flat
                        btn.ForeColor = Color.White
          
                ElseIf TypeOf obj Is DataGridView Then          'For Grid view
                    Dim gridview As DataGridView = obj
                    gridview.DefaultCellStyle.BackColor = Color.FromName(backcolor)
                    gridview.DefaultCellStyle.Font = New Font(fontname, fontsize, fs_fontstyle)
                    gridview.ForeColor = Color.FromName(forecolor)
                    gridview.Font = New Font(fontname, fontsize, fs_fontstyle)
                    'gridview.BackgroundColor = Color.FromName(backcolor)
                    gridview.BackgroundColor = Color.White
                    gridview.CellBorderStyle = DataGridViewCellBorderStyle.Raised
                    gridview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken
                    gridview.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
                ElseIf TypeOf obj Is ToolStrip Then             'For Toolstrip
                    Dim tstrip As ToolStrip = obj
                    tstrip.BackColor = Color.FromName(backcolor)
                    tstrip.Font = New Font(fontname, fontsize, fs_fontstyle)
                    tstrip.ForeColor = Color.FromName(forecolor)
    
                ElseIf TypeOf obj Is ToolStripButton Then       'For Toolstrip Button
                    Dim tbtn As ToolStripButton = obj
                    tbtn.BackColor = Color.FromName(backcolor)
                    tbtn.ForeColor = Color.FromName(forecolor)
                    tbtn.Font = New Font(fontname, fontsize, fs_fontstyle)
    
                ElseIf TypeOf obj Is Panel Then                 'For Panel
                    Dim pnl As Panel = obj
                    pnl.BackColor = Color.FromName(backcolor)
                    pnl.ForeColor = Color.FromName(forecolor)
                    pnl.Font = New Font(fontname, fontsize, fs_fontstyle)
                    sub_Form_Validators(obj)
    
                ElseIf TypeOf obj Is GroupBox Then              'For Group Box
                    Dim grp As GroupBox = obj
                    grp.BackColor = Color.FromName(backcolor)
                    grp.ForeColor = Color.FromName(forecolor)
                    grp.Font = New Font(fontname, fontsize, fs_fontstyle)
    
                ElseIf TypeOf obj Is Label Then                 'For Label
                    Dim lbl As Label = obj
                    lbl.BackColor = Color.FromName(backcolor)
                    lbl.Font = New Font(fontname, fontsize, fs_fontstyle)
                    lbl.ForeColor = Color.FromName(forecolor)
    
                Else
                    sub_Form_Validators(obj)
                End If
            Next
        End Sub
