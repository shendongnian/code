     using UnityEngine;
     using UnityEngine.UI;
     using System.Text;
     using System.Xml;
     using System.Collections;
     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Xml.Serialization;
     using System.IO;
     using GoogleMobileAds;
     using GoogleMobileAds.Api;
    
     public class responder : MonoBehaviour
     {
         private InterstitialAd adObject;
    
         private int gecis;
    
         public Text questionsorular;
         public Text responseA;
         public Text responseB;
         public Text responseC;
         public Text responseD;
         public Text infoResponses;
         public Text infoResponses1;
         public Text example;
         public Text dogrusayisi;
    
         private float corrects;
         private float questoesquestions;
         private float media;
         private int Notice;
     }
    
     void Start()
     {
         GetNewAds( null, null );
     }
    
     public void response(string alternative)
     {
    
    
         if (alternative == "A")
         {
             if (responseA.text == infoResponses.text)
             {
                 corrects += 1;
                 nextQuestion();
             }
             else
             {
                 Invoke("wrong", 1);
             }
         }
    
         else if (alternative == "B")
         {
             if (responseB.text == infoResponses.text)
             {
                 corrects += 1;
                 nextQuestion();
             }
             else
             {
                 Invoke("wrong", 1);
             }
         }
    
         else if (alternative == "C")
         {
             if (responseC.text == infoResponses.text)
             {
                 corrects += 1;
                 nextQuestion();
             }
             else
             {
                 Invoke("wrong", 1);
             }
         }
    
         else if (alternative == "D")
         {
             if (responseD.text == infoResponses.text)
             {
                 corrects += 1;
                 nextQuestion();
             }
             else
             {
                 Invoke("wrong", 1);
             }
         }
     }
    
     void wrong()
     {
         StartCoroutine(ShowAds());
         Application.LoadLevel("Notice");
     }
    
    IEnumerator ShowAds()
        {
            while( !adObject.IsLoaded() )
                yield return null;
     
            adObject.Show();
        }
     
        public void GetNewAds( object sender, EventArgs args )
        {
            if( adObject != null )
                adObject.Destroy();
             
            adObject = new InterstitialAd( "AD UNIT ID" );
            adObject.AdClosed += GetNewAds;
             
            AdRequest GetAds = new AdRequest.Builder().Build();
            adObject.LoadAd( GetAds );
        }
    }
