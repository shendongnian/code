    using UnityEngine;
    using UnityEngine.UI;
    public class RPB : MonoBehaviour {
      public Image LoadingBar;
      public Text TextIndicator;
      // other variables redacted //
      void Start () {
        LoadingBar = GetComponent<Image>();
        TextIndicator = GetComponent<Text>();
      }
      void Update () {
        // other functions redacted //
        LoadingBar.fillAmount = currentAmount / 100;
        TextIndicator.text = ((int)numSec).ToString () + "s";
      }
      public void TouchFunction() {
        // Do the thing here. //
      }
    }
