    using UnityEngine;
    using System.Collections;
    public class AndroidExit : MonoBehaviour
    {    
    #if UNITY_ANDROID
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MobileNativeDialog dialog = new MobileNativeDialog("Dialog Title", "Dialog message");
                //   Application.Quit();
                dialog.OnComplete += OnDialogClose;
            }
    #endif
        }
        private void OnDialogClose(MNDialogResult result)
        {
            switch (result)
            {
                case MNDialogResult.YES:
                    //Debug.Log("Yes button pressed");
                    Application.Quit();
                    break;
                case MNDialogResult.NO:
                    Debug.Log("No button pressed");
                    break;
            }
        }   
    } 
