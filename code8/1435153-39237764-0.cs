    '
    'PictureBox1
    '
    Me.PictureBox1.Location = New System.Drawing.Point(96, 87)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(231, 195)
    Me.PictureBox1.TabIndex = 0
    Me.PictureBox1.TabStop = False
    '
    'VScrollBar1
    '
    Me.VScrollBar1.Location = New System.Drawing.Point(330, 88)
    Me.VScrollBar1.Name = "VScrollBar1"
    Me.VScrollBar1.Size = New System.Drawing.Size(34, 194)
    Me.VScrollBar1.TabIndex = 2
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(0, 0)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(211, 251)
    Me.TextBox1.TabIndex = 3
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(522, 392)
    Me.Controls.Add(Me.VScrollBar1)
    Me.Controls.Add(Me.PictureBox1)
    '======= THIS IS THE CRITICAL CHANGE ======= 
    PictureBox1.Controls.Add(Me.TextBox1)
