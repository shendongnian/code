    using UnityEngine.UI;       // for RawImage
    public RawImage rawImage;   // public, so remember to drag-assign in editor
    private void OnTrackingFound()
    {
        VuforiaBehaviour.Instance.enabled = false;             // disable Vuforia
        rawImage.gameObject.SetActive(true);                   // enable the RawImage
        ((MovieTexture)rawImage.material.mainTexture).Play();  // play the movie
    }
