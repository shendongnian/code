    public interface ICopyableFrom<T>
    {
    	 void CopyAttributes(T src);
    }
    
    public void createCard<T>(GameObject whereToPut, T objectToCopy, Player player, CardStatus cardStatus) where T : BasicCardModel, ICopyableFrom<T>
    {
            GameObject new_card = Instantiate(basicCard);
            new_card.transform.SetParent(whereToPut.transform, false);
            Destroy(new_card.GetComponent<BasicCardModel>());
            new_card.AddComponent<T>();
            new_card.GetComponent<T>().CopyAttributes(objectToCopy);
            new_card.GetComponent<T>().linkModelToCardObject(new_card);
            new_card.GetComponent<T>().setUpCard<T>(player, cardStatus);
    }
