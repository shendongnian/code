    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class Test : MonoBehaviour
    {
        public Text textToAnimate;
        public Image imageToAnimate;
    
        // Use this for initialization
        void Start()
        {
            StartCoroutine(CODGhostEffect(textToAnimate, imageToAnimate));
        }
    
        private IEnumerator CODGhostEffect(Text text, Image image)
        {
            //Step 1 Enable Image
            image.gameObject.SetActive(true);
    
            Color defaultTextColor = text.color;
    
            Color invisibleTextColor = text.color;
            invisibleTextColor.a = 0; //Set Alpha to 0
    
            //Image RectTransform
            RectTransform imageRect = image.GetComponent<RectTransform>();
            Vector2 defaultImageSize = Vector2.zero;
            defaultImageSize = imageRect.sizeDelta;
    
            //Make the size of the Image to be 5x bigger then scale it back to be original size over time
            Vector2 scaledImageSize = defaultImageSize * 5;
            imageRect.sizeDelta = scaledImageSize; //Set the image size to be 5x 
            float imageAppearTime = 0.3f;
            float counter = 0;
            while (counter < imageAppearTime)
            {
                counter += Time.deltaTime;
                float time = counter / imageAppearTime;
    
                //Scale the image back to the original Size size OverTime 
                imageRect.sizeDelta = Vector2.Lerp(scaledImageSize, defaultImageSize, time);
                yield return null;
            }
    
            //Step 2 Wait for 0.3 Seconds
            yield return new WaitForSeconds(0.3f);
    
    
            //Step 3 Enable Text
            text.gameObject.SetActive(true);
    
            //Make the font size of the Text to be 4x bigger then scale it back to be original size over time
            int defaultTextSize = text.fontSize;
            int scaledTextSize = defaultTextSize * 4;
            text.fontSize = scaledTextSize; //Set the text font size to be 4x 
    
            float textAppearTime = 0.2f;
            counter = 0;
            while (counter < imageAppearTime)
            {
                counter += Time.deltaTime;
                float time = counter / textAppearTime;
    
                //Scale the text font size back to the original Size  OverTime 
                text.fontSize = (int)Mathf.Lerp(scaledTextSize, defaultTextSize, time);
                yield return null;
            }
    
            //Step 4 Wait for 1 Seconds
            yield return new WaitForSeconds(1.0f);
    
            float textBlinkTime = 0.1f; //Time between blinking Text
            WaitForSeconds waitTime = new WaitForSeconds(textBlinkTime);
    
            //Step 5 Blink Text
            /////////////////////////Flash Text/////////////////////////
            for (int i = 0; i < 4; i++)
            {
                //Hide Text by setting alpha to 0
                text.color = invisibleTextColor;
    
                yield return waitTime; //Wait 
    
                //Show Text by setting alpha to defaultvalue
                text.color = defaultTextColor;
    
                yield return waitTime; //again 
            }
    
            //Step 6 Disable Text
            text.gameObject.SetActive(false);
    
            //Reset text color to default color
            text.color = defaultTextColor;
    
            /////////////////////////SLOWLY MAKE Image DISAPPEAR/////////////////////////
            Color defaultImageColor = image.color;
            Color invisibleImageColor = image.color;
            invisibleImageColor.a = 0; //Set Alpha to 0
    
    
            Vector2 halfImageSize = Vector2.zero;
            halfImageSize = defaultImageSize / 2;
    
            //Step 7 Wait for 3 Seconds
            yield return new WaitForSeconds(0.3f);
    
            //Step 8 Animate Image disappearance
            float imageDisappearTime = 0.2f; //How long to hide the UI Image (0.2 seconds)
            counter = 0;
            while (counter < imageDisappearTime)
            {
                counter += Time.deltaTime;
                float time = counter / imageDisappearTime;
    
                //Scale to half size OverTime 
                imageRect.sizeDelta = Vector2.Lerp(defaultImageSize, halfImageSize, time);
    
                //Fade OverTime
                image.color = Color.Lerp(defaultImageColor, invisibleImageColor, time);
                yield return null;
            }
    
            //Disable Image
            image.gameObject.SetActive(false);
    
            //Reset image size to default size
            imageRect.sizeDelta = defaultImageSize;
    
            //Reset image color to default color
            image.color = defaultImageColor;
        }
    }
