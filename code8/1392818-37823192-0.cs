    public double Density(double x)
    {
        return PDF(_alpha, _beta, _scale, _location, x);
    }
    /// <summary>
    /// Computes the probability density of the distribution (PDF) at x, i.e. ∂P(X ≤ x)/∂x.
    /// </summary>
    /// <param name="alpha">The stability (α) of the distribution. Range: 2 ≥ α > 0.</param>
    /// <param name="beta">The skewness (β) of the distribution. Range: 1 ≥ β ≥ -1.</param>
    /// <param name="scale">The scale (c) of the distribution. Range: c > 0.</param>
    /// <param name="location">The location (μ) of the distribution.</param>
    /// <param name="x">The location at which to compute the density.</param>
    /// <returns>the density at <paramref name="x"/>.</returns>
    /// <seealso cref="Density"/>
    public static double PDF(double alpha, double beta, double scale, double location, double x)
    {
        if (alpha <= 0.0 || alpha > 2.0 || beta < -1.0 || beta > 1.0 || scale <= 0.0)
        {
            throw new ArgumentException(Resources.InvalidDistributionParameters);
        }
        if (alpha == 2d)
        {
            return Normal.PDF(location, Constants.Sqrt2*scale, x);
        }
        if (alpha == 1d && beta == 0d)
        {
            return Cauchy.PDF(location, scale, x);
        }
        if (alpha == 0.5d && beta == 1d && x >= location)
        {
            return (Math.Sqrt(scale/Constants.Pi2)*Math.Exp(-scale/(2*(x - location))))/Math.Pow(x - location, 1.5);
        }
        throw new NotSupportedException();
    }
