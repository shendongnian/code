    Dim key As Microsoft.Win32.RegistryKey =  Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion")
    Dim operatingSystem As String = ""
    
    If key IsNot Nothing
        operatingSystem = key.GetValue("ProductName")
    End If
    If operatingSystem.Contains("Windows 10")
        Dim verticalHiderLabel As New Label With {  .Location = New Point(Panel1.Right - SystemInformation.VerticalScrollBarWidth-1, Panel1.Top+1),
                                                    .Size = New Size(1, Panel1.Height - SystemInformation.HorizontalScrollBarHeight-1)}
        
        Dim horizontalHiderLabel As New Label With {.Location = New Point(Panel1.Left+1, Panel1.Bottom - SystemInformation.HorizontalScrollBarHeight-1),
                                                    .Size = New Size(Panel1.Width - SystemInformation.VerticalScrollBarWidth-1, 1)}
        Me.Controls.Add(verticalHiderLabel)
        Me.Controls.Add(horizontalHiderLabel)
        verticalHiderLabel.BringToFront()
        horizontalHiderLabel.BringToFront()
    End If
