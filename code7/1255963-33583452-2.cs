    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using System.IO;
    
    namespace TestStuff
    {
        [Activity(Label = "Main",MainLauncher=true,Icon = "@drawable/icon")]			
        public class MainActivity : Activity
        {
            //path of folder,where we want to save our .txt File(Downloads)
            Java.IO.File FolderToSave = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
           
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                SetContentView(Resource.Layout.Second);
                EditText login = FindViewById<EditText>(Resource.Id.editText1);
                EditText password = FindViewById<EditText>(Resource.Id.editText2);
                Button btn = FindViewById<Button>(Resource.Id.btn);
                //here is final Path of our Credentials.txt
                string filePath = System.IO.Path.Combine(FolderToSave.Path, "Credentials.txt");
                //method,that will write correct login/password to .txt file
                this.WriteFile("Vasya", "12345",filePath);
                //eventhandler,when we pressing the button,method "check credentials will do some stuff
                btn.Click += (sender, e) => 
                    {
                      //put parametrs: location of Credentials.txt and    current login and password
      CheckForCredentials(filePath,login.Text,password.Text);
                        };
    
            }
            //create and write credentials.txt with login and pass
            void WriteFile(string Login,string Password,string Path)
            {
                using (StreamWriter Credentials = new StreamWriter (Path))
                {
                    //first row will be our login
                    Credentials.WriteLine(Login);
                    //second is password
                    Credentials.WriteLine(Password);
                }
            }
    
            //check for correct data
            void CheckForCredentials(string Path,string CurrentLogin,string CurrentPassword)
            {
                string Login, Password;
                if (File.Exists(Path))
                {
                    //reading from Credentials.txt first rows(that is our login)
                    Login = File.ReadLines(Path).First();
                    //same for password
                    Password = File.ReadLines(Path).Last();
                    
                    //check if introduced values are correct!
                    if (Login == CurrentLogin && Password == CurrentPassword)
                    {
                        Toast.MakeText(this, "Credentials are correct", ToastLength.Short).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "Something going wrong", ToastLength.Short).Show();
                    }
                }
                else
                {
                    //credentials for some reason doest exist in your app.
                    Toast.MakeText(this, "Not exist file", ToastLength.Short).Show();
                }
            }
        }
    }
