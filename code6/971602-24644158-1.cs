	namespace TestForm
	{
		partial class testForm
		{
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.IContainer components = null;
			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
			protected override void Dispose(bool disposing)
			{
				if (disposing && (components != null))
				{
					components.Dispose();
				}
				base.Dispose(disposing);
			}
			#region Windows Form Designer generated code
			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				this.m_checkedListBox = new System.Windows.Forms.CheckedListBox();
				this.m_toggle = new System.Windows.Forms.Button();
				this.SuspendLayout();
				// 
				// m_checkedListBox
				// 
				this.m_checkedListBox.CheckOnClick = true;
				this.m_checkedListBox.FormattingEnabled = true;
				this.m_checkedListBox.Location = new System.Drawing.Point(13, 13);
				this.m_checkedListBox.Name = "m_checkedListBox";
				this.m_checkedListBox.Size = new System.Drawing.Size(171, 109);
				this.m_checkedListBox.TabIndex = 0;
				// 
				// m_toggle
				// 
				this.m_toggle.Location = new System.Drawing.Point(190, 53);
				this.m_toggle.Name = "m_toggle";
				this.m_toggle.Size = new System.Drawing.Size(75, 23);
				this.m_toggle.TabIndex = 1;
				this.m_toggle.Text = "Fill";
				this.m_toggle.UseVisualStyleBackColor = true;
				this.m_toggle.Click += new System.EventHandler(this.m_toggle_Click);
				// 
				// testForm
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(275, 135);
				this.Controls.Add(this.m_toggle);
				this.Controls.Add(this.m_checkedListBox);
				this.Name = "testForm";
				this.Text = "Form";
				this.Load += new System.EventHandler(this.testForm_Load);
				this.ResumeLayout(false);
			}
			#endregion
			private System.Windows.Forms.CheckedListBox m_checkedListBox;
			private System.Windows.Forms.Button m_toggle;
		}
	}
