    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    namespace DupeOnly {
    public partial class Form1 : Form{
       public Form1(){
          InitializeComponent();
       }
       private void button1_Click(object sender, EventArgs e){
          string zRegData = File.ReadAllText(@"C:\Users\user\documents\regdata.csv");
          HashSet<string> hsRegData = new HashSet<string>(); 
      bool tfFirst = true;
      string[] zAllPlateData = zRegData.Split(',');  //License plates don't have comma's
      List<Regex> rxList = new List<Regex>();
      rxList.Add(new Regex(@"[A-Z]{3}[0-9]{3}"));
      rxList.Add(new Regex(@"[A-Z]{2}[0-9]{2}[A-Z]{3}"));
      rxList.Add(new Regex(@"[A-Z]{1}[0-9]{3}[A-Z]{3}"));
      rxList.Add(new Regex(@"[A-Z]{1}[0-9]{2}[A-Z]{3}"));
      rxList.Add(new Regex(@"[A-Z]{1}[0-9]{1}[A-Z]{3}"));
      rxList.Add(new Regex(@"[A-Z]{3}[0-9]{2,3}"));
      rxList.Add(new Regex(@"[A-Z]{2}[0-9]{4}"));
      rxList.Add(new Regex(@"[A-Z]{3}[0-9]{2}"));
      rxList.Add(new Regex(@"[A-Z]{2}[0-9]{2}[A-Z]{3}"));
      Match m;
      using (StreamWriter sw = new StreamWriter(@"C: \Users\user\Desktop\usersNotes\plates.csv")){
         for(int Q = 0; Q < zAllPlateData.Length; Q++){
            if(hsRegData.Add(zAllPlateData[Q]) == false){
               //At this point we know it is a duplicate, must still match a check pattern
               foreach(Regex rx in rxList){
                  m = rx.Match(zAllPlateData[Q]);
                  if(m.Success){
                     if(tfFirst){
                        tfFirst = false;
                        sw.Write(zAllPlateData[Q]);  //First plate doesn't take a comma
                     }
                     else{
                        sw.Write("," + zAllPlateData[Q]);  //Comma delimit subsequent plates
                     }
                     break;
                  }
               }
            }
         }
          }
       }
    }
    }
