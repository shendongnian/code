    /*--------------------------------Program.cs------------------------------*/
        //Program.cs
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        
        namespace OpenTK_OrthoCamera
        {
            static class Program
            {
                /// <summary>
                /// The main entry point for the application.
                /// </summary>
                [STAThread]
                static void Main()
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }
        }
    
    
    /*--------------------------------Form1.Designer.cs------------------------*/
        namespace OpenTK_OrthoCamera
        {
            partial class Form1
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
                    this.glControl1 = new OpenTK.GLControl();
                    this.SuspendLayout();
                    // 
                    // glControl1
                    // 
                    this.glControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                    | System.Windows.Forms.AnchorStyles.Left) 
                    | System.Windows.Forms.AnchorStyles.Right)));
                    this.glControl1.BackColor = System.Drawing.Color.Black;
                    this.glControl1.Location = new System.Drawing.Point(12, 12);
                    this.glControl1.Name = "glControl1";
                    this.glControl1.Size = new System.Drawing.Size(892, 521);
                    this.glControl1.TabIndex = 0;
                    this.glControl1.VSync = false;
                    this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
                    this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
                    this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
                    this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
                    this.glControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.OnMouseWheel);
                    // 
                    // Form1
                    // 
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.ClientSize = new System.Drawing.Size(916, 545);
                    this.Controls.Add(this.glControl1);
                    this.Name = "Form1";
                    this.Text = "Form1";
                    this.ResumeLayout(false);
        
                }
              
        
                #endregion
        
                private OpenTK.GLControl glControl1;
            }
        }
    
    /*--------------------------------Form1.cs-------------------------------*/
        using OpenTK.Graphics.OpenGL;
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        
        namespace OpenTK_OrthoCamera
        {
            public partial class Form1 : Form
            {
                bool loaded = false;
        
                float x = 0;
                float y = 0;
                float z = 0;
        
        
                public Form1()
                {
                    InitializeComponent();
                }
        
                /// <summary>
                /// Loads Control
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void glControl1_Load(object sender, EventArgs e)
                {
                    loaded = true;
                    GL.ClearColor(Color.SkyBlue); // Yey! .NET Colors can be used directly!
        
                    SetupViewport();
                }
        
                /// <summary>
                /// Setup the Viewport
                /// </summary>
                private void SetupViewport()
                {
                  
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();            
        
                    int w = glControl1.Width;
                    int h = glControl1.Height;
        
                    float orthoW = w * (z + 1);
                    float orthoH = h * (z + 1);
        
                    GL.Ortho(0, orthoW, 0, orthoH, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
                    GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
                }
        
        
        
                /// <summary>
                /// Calculate Translation of  (X, Y, Z) - according to mouse input
                /// </summary>
                private void SetupCursorXYZ()
                {
                    x =   PointToClient(Cursor.Position).X  * (z + 1);
                    y = (-PointToClient(Cursor.Position).Y + glControl1.Height) * (z + 1); 
                }
        
        
                /// <summary>
                /// We need to setup each time our viewport and Ortho.
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void glControl1_Resize(object sender, EventArgs e)
                {
                    if (!loaded)
                        return;
        
                    SetupViewport();
                }
        
        
                /// <summary>
                /// Paint The control.
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void glControl1_Paint(object sender, PaintEventArgs e)
                {
                    if (!loaded) // Play nice
                        return;
        
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
        
                    GL.Translate(x, y, 0); // position triangle according to our x variable
        
                    GL.Color3(Color.Yellow);
                    GL.Begin(BeginMode.Triangles);
                    GL.Vertex2(10, 20);
                    GL.Vertex2(100, 20);
                    GL.Vertex2(100, 50);
                    GL.End();
        
                    glControl1.SwapBuffers();
        
                }
        
                /// <summary>
                /// The triangle will always move with the cursor. 
                /// But is is not a problem to make it only if mousebutton pressed. 
                /// And do some simple ath with old Translation and new translation.
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void glControl1_MouseMove(object sender, MouseEventArgs e)
                {
                    x = PointToClient(Cursor.Position).X  * (z + 1);
                    y = (-PointToClient(Cursor.Position).Y + glControl1.Height) * (z + 1);
        
                    SetupCursorXYZ();
        
                    glControl1.Invalidate();
                }
        
        
                private void OnMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
                {
                    if (e.Delta > 0 && z > 0) z -= 0.5f;
                    if (e.Delta < 0 && z < 5) z += 0.5f;
        
                    SetupCursorXYZ();
                 
                    SetupViewport();
                    glControl1.Invalidate();
                }
        
            }
        }
