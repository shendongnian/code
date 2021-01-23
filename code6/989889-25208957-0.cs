						var RandomRange = Random.Range (0, TheDealingDeck.Count - 1);
						var CardNumberToDraw = System.Convert.ToInt16 (TheDealingDeck [RandomRange]);
						GameObject.FindGameObjectWithTag ("Player 1 Card " + _p1).GetComponent<SpriteRenderer> ().sprite = CardSprites [CardNumberToDraw];
						PlayerOneHand.Add (TheNewDeck [CardNumberToDraw]);
						TheDealingDeck.RemoveAt (RandomRange);
