    public class CoinController: MonoBehaviour {
    	int coins;
    
    	public int Coins {
    		get {
    			return coins;
    		}
    	}
    
    	public Sprite GetSprite() {
    		//logic for determining sprite based on number of coins here
    	}
    
    
    	public void AddCoins(int num) {
    		coins += num;
    	}
    
    	public void SpendCoins(int num) {
    		coins -= num;
    	}
    }
    
    
    CoinController coinController = GetComponent<CoinController>();
    coinController.AddCoins(5);
    coinController.SpendCoins(2);
    
    //in update method
    Sprite thisSprite = coinController.GetSprite();
    //draw sprite logic, not sure how you're doing this, but DrawCoinSprite would be some method that updates which sprite to draw
    DrawCoinSprite(thisSprite);
