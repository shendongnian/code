    string GetPieceCode(GameObject piece)
        {
            string pieceCode = "";
            Debug.Log(piece.gameObject);
            pieceCode = piece.ToString().Substring(0,2);
            Debug.Log(pieceCode);
            return pieceCode;
        }
