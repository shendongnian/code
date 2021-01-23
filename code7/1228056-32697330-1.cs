    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    namespace wfAutoClose {
      public partial class Form1: Form {
        FormSubscriber formSubscriber = new FormSubscriber();
        public Form1() {
          InitializeComponent();
          formSubscriber.PropertyChanged += OnPropertyChanged;
        }
        private void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
          if (formSubscriber.FormCount == 0) {
            Application.Exit();
          }
        }
        private void Form1_Load( object sender, EventArgs e ) {
          for ( int i = 0; i < 3; i++ ) {
            Form form = new Form2() { Text = "Dynamic Form " + i };
            form.Show();
            formSubscriber.Forms.Add( form );
          }
        }
        private void Form1_FormClosed( object sender, FormClosedEventArgs e ) {
          formSubscriber.Dispose();
        }
      }
    }
