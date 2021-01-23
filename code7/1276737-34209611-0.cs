    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    public class POINTS1 : MonoBehaviour
    {
        public Text winText;
        public AudioSource pickUpAudio;
        public AudioSource minus300Audio;
    public int actualScore;
    public int highScore;
    public Text highscoreText;
	public Text actualScoreText;
    private int count;
    void Start()
    {
		highScore = PlayerPrefs.HasKey("highScore") ? PlayerPrefs.GetInt("highScore") : 0; //This will verify if the key highScore exists in your player prefs, if it exists it should retrieve the stored value if not will return 0;
		actualScoreText.Text = 0;
    }
    void Update()
    {
        // if (scoreText.name == "scoreText") //If you are going to set this in the editor, you don't need to verify the name of the object...
        // {
            // scoreText.text = "HS: " + highScore;
        // }
		
		//Set text for actualScore and highScore (notice that I've created another variable to display the actual score vs the highScore)
		actualScoreText.Text = actualScore.toString();
    // We compare the actual score vs the highScore if the actual is greater the we set it to the text variable.
    if(actualScore > highScore)
    highscoreText.Text = "HS: " + actualScore;
    else
    highscoreText.Text = "HS: " + highScore;
		 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            actualScore += 100;
            {
                pickUpAudio.Play();
            }
        }
        else if (other.gameObject.CompareTag("minus300"))
        {
            other.gameObject.SetActive(false);
            actualScore -=  300;
			if(actualScore < 0) actualScore = 0; //Actual score can not be below 0
            {
                minus300Audio.Play();
            }
        }
    }
	//I don't know why you called this code many times in the OnTriggerEnter() ....
    // void SetCountText()
    // {
        // PlayerPrefs.SetInt("score", count);
        // PlayerPrefs.Save();
        // count = PlayerPrefs.GetInt("score", 0);
        // countText.text = "Score: " + count.ToString();
        // if (count >= 5000)
        // {
            // winText.text = "Good Job!";
        // }
            // score1 = count;
        // if (score1 > count);
        // {
            // scoreText.text = "HS: " + score1;
        // }
        // if (score2 > score1);
        // {
            // scoreText.text = "Score2> 1 " + score1;
        // }
    // }
	
	void GameOver() //Call GameOver whenever your game is... over, let say .. when your player got N amount of points or N amount of damage...
	{
		if(actualScore >= 5000)
			winText.text = "Good Job";
		
		if(actualScore >= highScore)
			PlayerPrefs.SetInt("highScore", actualScore); //this will save the highscore and will display it the next time Start() is called, you need to call GameOver() somewhere in your code....
	}
    }
