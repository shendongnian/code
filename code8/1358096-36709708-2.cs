    var intermediateObject = camera.gameObject.transform.DOMove(target,3.0f)                   
        .SetEase(Ease.InOutQuad);
    
    if (visible) {
        intermediateObject.OnStart(animation.FadeOut).OnComplete(animation.FadeIn);;
    }
    else {
        intermediateObject.OnComplete(animation.FadeIn);;
    }
